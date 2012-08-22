<script id="shader-fs" type="x-shader/x-fragment">
	varying highp vec4 vColor;
    varying highp vec3 vLight;

	void main(void) {
		gl_FragColor = vec4(vColor.xyz * vLight, vColor.a);
	}
</script>