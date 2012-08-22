<script type="x-shader/x-vertex">
	attribute vec3 aVertexPosition;
	
	uniform mat4 uPMatrix;
	uniform mat4 uMVMatrix;
	uniform sampler2D uSampler;

	varying highp float height;
	
	void main(void) {
		height = texture2D( uSampler, vec2(aVertexPosition.xz )).r;
		gl_Position = uPMatrix * uMVMatrix * vec4(aVertexPosition.x, height, aVertexPosition.z, 1.0);
	}
</script>