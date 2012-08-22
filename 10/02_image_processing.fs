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
			finalColor = texColor.gbra;
		}else if(uEffect == 1){
			highp vec3 sepia = vec3( 
								min( (texColor.r * .393) + (texColor.g *.769) + (texColor.b * .189), 1.0),
								min( (texColor.r * .349) + (texColor.g *.686) + (texColor.b * .168), 1.0),
								min( (texColor.r * .272) + (texColor.g *.534) + (texColor.b * .131), 1.0)
							   );
			finalColor = vec4(sepia, 1.0);
		}

		gl_FragColor = finalColor;	
	}
</script>