<script type="x-shader/x-vertex">
	uniform mat4 uMVMatrix;
	uniform mat4 uPMatrix;

	attribute vec3 aVertexPosition;
	attribute vec4 aVertexColor;
	attribute vec3 aVertexNormal;

	varying highp vec4 vColor;
	varying highp vec3 vPosition;
	varying highp vec3 N;

	void main(void) {
		gl_Position = uPMatrix * uMVMatrix * vec4(aVertexPosition, 1.0);
        
        vColor = aVertexColor;
        vPosition = aVertexPosition;
		N = aVertexNormal; 		
	}
</script>