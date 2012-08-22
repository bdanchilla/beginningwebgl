<script id="shader-fs" type="x-shader/x-fragment">
	uniform sampler2D uFBOTexture;

	varying highp vec3 vPosition;
	void main(void) {
		highp vec2 texCoord = vPosition.xz/2.0 + 0.5 ;
	    gl_FragColor = vec4(texture2D( uFBOTexture, vec2(texCoord)).rgb, 1.0 );
	}
</script>