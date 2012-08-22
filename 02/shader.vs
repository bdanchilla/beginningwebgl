<script type="x-shader/x-vertex">
	attribute vec3 aVertexPosition;
	attribute vec3 aVertexColor;

	uniform mat4 uMVMatrix;
	uniform mat4 uPMatrix;

	varying highp vec4 vColor;	
	void main(void) {
		gl_Position = uPMatrix * uMVMatrix * vec4(aVertexPosition, 1.0);
		vColor = vec4(aVertexColor, 1.0);
	}
</script>