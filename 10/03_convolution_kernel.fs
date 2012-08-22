<script id="shader-fs" type="x-shader/x-fragment">
	varying highp vec2 position;
	uniform sampler2D uSampler;
	uniform highp vec2 uTexDimensions;
	uniform highp float uKernel[9];
	uniform highp float uKernelWeight;
	
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

	   gl_FragColor = vec4( colorSum.rgb/weight, 1.0 );
	}
</script>