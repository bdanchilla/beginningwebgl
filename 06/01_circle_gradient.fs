<script id="shader-fs" type="x-shader/x-fragment">
	varying highp vec2 position;
	void main(void) {   
		highp float d = length(position);
		gl_FragColor = vec4(max(0.0, 1.0 - d), 0.0, 0.0, 1.0);
	}
</script>