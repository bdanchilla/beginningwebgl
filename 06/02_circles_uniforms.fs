<script id="shader-fs" type="x-shader/x-fragment">
	uniform sampler2D sColors;
	varying highp vec2 position;

	void main(void) {   
		highp float t = length(position);
		gl_FragColor = vec4(texture2D(sColors, vec2(0.0, t)).rgb, 1.0);
	}
</script>