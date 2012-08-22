<script type="x-shader/x-vertex">
	attribute vec3 aVertexPosition;
	attribute vec3 aVertexColor;
	attribute vec3 aVertexNormal;

	uniform mat3 uNormalMatrix;
	uniform mat4 uMVMatrix;
	uniform mat4 uPMatrix;

	varying highp vec4 vColor;	
	varying highp vec3 vLight;

	void main(void) {
		gl_Position = uPMatrix * uMVMatrix * vec4(aVertexPosition, 1.0);
        vColor = vec4(aVertexColor, 1.0);

		//lighting
        vec3 ambientLight = vec3(0.1, 0.1, 0.1);
        vec3 directionalLightColor = vec3(0.5, 0.5, 0.5);        
        vec3 directionalLightPosition = normalize( vec3(10.0, 10.0, 5.0) );

        vec3 transformedNormal = uNormalMatrix * aVertexNormal;                
        float diffuseLightAmount = max( dot(transformedNormal, directionalLightPosition), 0.0);	    
	    vLight = ambientLight + (diffuseLightAmount * directionalLightColor);
	}
</script>