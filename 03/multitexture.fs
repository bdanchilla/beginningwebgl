<script id="shader-fs" type="x-shader/x-fragment">
    varying highp vec2 vTextureCoord;
    uniform sampler2D uSampler;
    uniform sampler2D uSampler2;
    uniform int uDoTexturing;
	
	void main(void) {
		if(uDoTexturing == 1){
			highp vec4 stoneColor = texture2D(uSampler, vec2(vTextureCoord.st));
			highp vec4 webglLogoColor = texture2D(uSampler2, vec2(vTextureCoord.st));
			gl_FragColor = mix(stoneColor, webglLogoColor, 0.5);
			//gl_FragColor = mix(stoneColor, webglLogoColor, webglLogoColor.a);
			//gl_FragColor = mix(stoneColor, webglLogoColor, 1.0 - webglLogoColor.a);
		}else{
			gl_FragColor = vec4(1.0, 0.1, 0.1, 1.0); 
		}	
	}
</script>