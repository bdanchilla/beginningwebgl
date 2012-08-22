<script type="x-shader/x-vertex">
	uniform mat4 uLightMVMatrix;
	uniform mat4 uPMatrix;

	attribute vec3 aVertexPosition;

	void main(void) {
		gl_Position = uPMatrix * uLightMVMatrix * vec4(aVertexPosition, 1.0);
	}
</script>