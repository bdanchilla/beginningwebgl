<script type="x-shader/x-vertex">
	attribute vec3 aVertexPosition;
	attribute vec3 aVertexColor;
	attribute vec3 aVertexNormal;

	uniform mat3 uNormalMatrix;
	uniform mat4 uMVMatrix;
	uniform mat4 uPMatrix;

	varying vec3 vColor;
    varying float diffuseLambert;
    varying float specular;

	void main(void) {
		gl_Position = uPMatrix * uMVMatrix * vec4(aVertexPosition, 1.0);
        vColor = aVertexColor;

        vec3 pointLightPosition = vec3(1.0,2.0,-1.0);
        vec3 pointLightDirection = vec3(pointLightPosition.xyz - aVertexPosition.xyz);
        
        vec3 L = vec3(uPMatrix * uMVMatrix * vec4(pointLightDirection, 1.0));
		vec3 N = normalize(uNormalMatrix * aVertexNormal); 		
		vec3 V = -vec3(uPMatrix * uMVMatrix * vec4(aVertexPosition,1.0));

		L = normalize(L);
    	V = normalize(V);
		
		vec3 R = reflect(-L, N);
		float shininess = 128.0;
		
		specular = pow( max(0.0,dot(R,V)), shininess);
		diffuseLambert = dot(L,N);
	}
</script>