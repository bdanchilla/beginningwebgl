<script id="shader-fs" type="x-shader/x-fragment">
    varying highp float vLight;
    varying highp vec2 vTextureCoord;
    
    uniform sampler2D uSampler;

	void main(void) {
		highp vec4 textureColor = texture2D(uSampler, vec2(vTextureCoord.st));
		gl_FragColor = vec4(textureColor.xyz * vLight, textureColor.a);
	}
</script>