<script id="shader-fs" type="x-shader/x-fragment">
    varying highp vec2 vTextureCoord;
    uniform sampler2D uSampler;
	
	void main(void) {
		gl_FragColor = texture2D( uSampler, vec2(vTextureCoord.s, vTextureCoord.t) );
	}
</script>
