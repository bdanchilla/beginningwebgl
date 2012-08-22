<script id="shader-fs" type="x-shader/x-fragment">
	varying highp vec2 position;
	uniform sampler2D uSampler;
	uniform int uEffect;
	
	void main(void) {
		//convert texture coordinates from [-1, 1] to [0, 1]
		highp vec2 texCoords = position * 0.5 + .5;

		highp vec4 texColor = texture2D( uSampler, vec2(texCoords.s, texCoords.t) );
		highp vec4 finalColor;

		if(uEffect == 0){
			finalColor = texColor;
		}else if(uEffect == 1){
			finalColor = vec4( vec3(1.0, 1.0, 1.0) - texColor.rgb, 1.0 );
		}else if(uEffect == 2){
			highp float gray = (texColor.r  + texColor.g + texColor.b)/3.0;
			finalColor = vec4( gray, gray, gray, 1.0);
		}else if(uEffect == 3){
			texColor.rb *= 0.8;
			finalColor = texColor;
		}

		gl_FragColor = finalColor;	
	}
</script>