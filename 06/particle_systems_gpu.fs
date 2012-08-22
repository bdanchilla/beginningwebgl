<script id="shader-fs" type="x-shader/x-fragment">
	varying highp float parametricTime;
	void main(void) {   
		gl_FragColor = vec4(parametricTime*.8, parametricTime*.8, 1.0, 0.9-(parametricTime*.4));
	}
</script>