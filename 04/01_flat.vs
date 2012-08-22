<script type="x-shader/x-vertex">
	attribute vec3 aVertexPosition;
	attribute vec3 aVertexColor;
	attribute vec3 aVertexNormal;

	uniform mat3 uNormalMatrix;
	uniform mat4 uMVMatrix;
	uniform mat4 uPMatrix;

	varying highp vec3 vColor;
	varying highp vec3 L;
	varying highp vec3 N;

	void main(void) {
		gl_Position = uPMatrix * uMVMatrix * vec4(aVertexPosition, 1.0);
        
        vec3 pointLightPosition = vec3(1.0,2.0,-1.0);
        vec3 pointLightDirection = normalize(vec3(pointLightPosition.xyz - aVertexPosition.xyz));
        vec3 ambientColor = vec3(0.1, 0.1, 0.1);

		L = vec3(uPMatrix * uMVMatrix * vec4(pointLightDirection, 1.0));
		N = uNormalMatrix * aVertexNormal;
	 		
		vColor = aVertexColor;
	}
</script>