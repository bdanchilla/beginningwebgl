<script id="shader-fs" type="x-shader/x-fragment">
	varying highp float height;
	void main(void) {   

		gl_FragColor = vec4(height, height, height, 1.0);
	}
</script>