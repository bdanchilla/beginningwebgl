<script type="x-shader/x-vertex">
	attribute vec3 aVertexPosition;

	varying vec2 position;
	void main(void) {
		position = vec2(aVertexPosition.xy);
		gl_Position = vec4(position, 0.0, 1.0);
	}
</script>