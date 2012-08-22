<script id="shader-fs" type="x-shader/x-fragment">
	varying highp vec2 position;
	void main(void) {   
		highp float d = length(position);
		highp float c = floor(d*10.0) * 0.1;
		gl_FragColor = vec4(max(0.0, 1.0 - c), 0.0, 0.0, 1.0);
	}
</script>