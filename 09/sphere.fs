<script id="shader-fs" type="x-shader/x-fragment">
    varying highp vec3 vLight;
    varying highp vec2 vTextureCoord;
    
    uniform sampler2D uSampler;
    uniform sampler2D uSampler2;

	void main(void) {
		highp vec4 stoneColor = texture2D(uSampler, vec2(vTextureCoord.st));
		highp vec4 webglLogoColor = texture2D(uSampler2, vec2(vTextureCoord.st));
		highp vec4 textureColor = mix(stoneColor, webglLogoColor, webglLogoColor.a);
		gl_FragColor = vec4(textureColor.xyz * vLight, textureColor.a);
	}
</script>