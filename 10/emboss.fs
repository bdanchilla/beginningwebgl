<script id="shader-fs" type="x-shader/x-fragment">
	varying highp vec2 position;
	uniform sampler2D uSampler;
	uniform highp vec2 uTexDimensions;
	uniform highp float uKernel[9];
	uniform highp float uKernelWeight;
	uniform highp int uEmboss;
	
	void main(void) {
		//convert texture coordinates from [-1, 1] to [0, 1]
		highp vec2 texCoords = position * 0.5 + .5;

		//find the size of each pixel relative to the [0, 1] range
		highp vec2 texelSize = vec2(1.0, 1.0) / uTexDimensions;

		//modified from http://games.greggman.com/game/webgl-image-processing/
		highp vec4 colorSum =
	     texture2D(uSampler, texCoords + texelSize * vec2(-1, -1)) * uKernel[0] +
	     texture2D(uSampler, texCoords + texelSize * vec2( 0, -1)) * uKernel[1] +
	     texture2D(uSampler, texCoords + texelSize * vec2( 1, -1)) * uKernel[2] +

	     texture2D(uSampler, texCoords + texelSize * vec2(-1,  0)) * uKernel[3] +
	     //central pixel
	     texture2D(uSampler, texCoords) * uKernel[4] +     
	     texture2D(uSampler, texCoords + texelSize * vec2( 1,  0)) * uKernel[5] +

	     texture2D(uSampler, texCoords + texelSize * vec2(-1,  1)) * uKernel[6] +
	     texture2D(uSampler, texCoords + texelSize * vec2( 0,  1)) * uKernel[7] +
	     texture2D(uSampler, texCoords + texelSize * vec2( 1,  1)) * uKernel[8];

	   highp float weight;
	   weight = uKernelWeight;
	   if (0.01 > weight) {
    	 	weight = 1.0;
	   }

		highp vec3 color = (colorSum/weight).rgb;

		if(uEmboss == 1)
		{
			//to grayscale
			highp float gray = dot(color, vec3(.3,.59,.11) )  +.5;				   
			highp vec3 finalColor = vec3(gray,gray,gray);		
	        gl_FragColor = vec4( finalColor, 1.0 );
		}else{
		    gl_FragColor = vec4( color, 1.0 );
		}	
	}
</script>