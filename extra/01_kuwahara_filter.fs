<script id="shader-fs" type="x-shader/x-fragment">
	varying highp vec2 position;
	uniform sampler2D uSampler;
	uniform highp vec2 uTexDimensions;
	uniform int uFilterOn;
	const int filter_size = 4;

	//global variables

	//convert texture coordinates from [-1, 1] to [0, 1]
	highp vec2 texCoords = vec2(0.0, 0.0);
	//find the size of each pixel relative to the [0, 1] range
	highp vec2 texelSize = vec2(1.0, 1.0) / uTexDimensions;

	highp vec3 cumulative_rgb = vec3(0.0, 0.0, 0.0);
	highp float cumulative_lumination = 0.0;
	highp float cumulative_lumination2 = 0.0;
	highp float current_variance = 0.0;
	highp float best_variance = 2.0;
	highp float current_lumination = 0.0;
	highp float min = 1.0;
	highp float max = 0.0;
 	highp vec4 best_color = vec4(0.0, 0.0, 0.0, 1.0);

	void calculateLuminance(int x_offset, int y_offset)
	{
		texCoords = position * 0.5 + .5;
		highp vec2 texels = texCoords + texelSize * vec2(x_offset, y_offset);
		highp vec3 rgb = texture2D(uSampler, texels).rgb;
		current_lumination = dot(rgb, vec3(0.3, 0.59, 0.11));
		current_lumination /= 255.0;
		
		cumulative_lumination += current_lumination;
		cumulative_lumination2 += (current_lumination*current_lumination);
		
		cumulative_rgb += rgb;

		if(current_lumination &lt; min)
		{
			min = current_lumination;
		}

		if(current_lumination &gt; max)
		{
			max = current_lumination;
		}
	}

	void reset()
	{
		min = 1.0;
		max = 0.0;
		cumulative_rgb = vec3(0.0, 0.0, 0.0);
		cumulative_lumination = 0.0;
		cumulative_lumination2 = 0.0;
	}

	void tidyUp()
	{
		highp float weight = float(filter_size * filter_size);
		//E(X^2) - (E(X))^2
		current_variance = cumulative_lumination2 - (cumulative_lumination*cumulative_lumination)/weight;

		if(best_variance > current_variance)
		{
			best_variance = current_variance;
			best_color = vec4(cumulative_rgb/weight, 1.0);
		}

		reset();
	}

	void main(void) {
	    if(uFilterOn == 0)
	    {
			texCoords = position * 0.5 + .5;
	    	best_color = texture2D(uSampler, texCoords);
	    }else{

			//quadrant A 
			for(int i=0; i&lt;filter_size; ++i)
			{
				for(int j=0; j&lt;filter_size; ++j)
				{
					calculateLuminance(i, j);
				}
			}

			tidyUp();

			//quadrant B 
			for(int i=0; i&lt;filter_size; ++i)
			{
				for(int j=0; j&lt;filter_size; ++j)
				{
					calculateLuminance(-i, j);
				}
			}

			tidyUp();
			
			//quadrant C 
			for(int i=0; i&lt;filter_size; ++i)
			{
				for(int j=0; j&lt;filter_size; ++j)
				{
					calculateLuminance(-i, -j);
				}
			}

			tidyUp();

			//quadrant D 
			for(int i=0; i&lt;filter_size; ++i)
			{
				for(int j=0; j&lt;filter_size; ++j)
				{
					calculateLuminance(i, -j);
				}
			}

			tidyUp();
	    }
        gl_FragColor = best_color;
	}
</script>