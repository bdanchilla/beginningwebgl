<script type="x-shader/x-vertex">
	attribute vec3 aVertexPosition;
	attribute vec4 aVertexColor;
	
	uniform mat4 uPMatrix;
	uniform mat4 uMVMatrix;

	varying vec4 color;

	void main(void) {
		color = aVertexColor;
		gl_PointSize = 3.0;
		gl_Position = uPMatrix * uMVMatrix * vec4(aVertexPosition.xyz, 1.0);
	}
</script>