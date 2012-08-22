<script type="x-shader/x-vertex">
	attribute vec3 aVertexPosition;
	attribute vec2 aVertexTexCoord;

	uniform mat4 uMVMatrix;
	uniform mat4 uPMatrix;

	varying highp vec2 vTextureCoord;

	void main(void) {
		gl_Position = uPMatrix * uMVMatrix * vec4(aVertexPosition, 1.0);
        vTextureCoord = aVertexTexCoord;
	}
</script>