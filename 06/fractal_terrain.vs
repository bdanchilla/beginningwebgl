<script type="x-shader/x-vertex">
	attribute vec3 aVertexPosition;
	
	uniform mat4 uPMatrix;
	uniform mat4 uMVMatrix;

	varying highp vec3 position;

	void main(void) {
		position = aVertexPosition;
		position.y *= 1.2;
		gl_Position = uPMatrix * uMVMatrix * vec4(position, 1.0);
	}
</script>