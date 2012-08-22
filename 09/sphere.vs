<script type="x-shader/x-vertex">
	attribute vec3 aVertexPosition;
	attribute vec3 aVertexPosition2;
	attribute vec3 aVertexNormal;
	attribute vec2 aVertexTexCoord;

	uniform mat3 uNormalMatrix;
	uniform mat4 uMVMatrix;
	uniform mat4 uPMatrix;

	varying highp vec3 vLight;
	varying highp vec2 vTextureCoord;

	void main(void) {
		
		gl_Position = uPMatrix * uMVMatrix * vec4(aVertexPosition, 1.0);
    	vTextureCoord = aVertexTexCoord;
    
		//lighting
        vec3 ambientLight = vec3(0.3, 0.3, 0.3);
        vec3 pointLightColor = vec3(0.5, 0.5, 0.5);        

        vec3 pointLightPosition = vec3(1.0,2.0,-1.0);
        vec3 pointLightDirection = vec3(pointLightPosition.xyz - aVertexPosition.xyz);

        vec3 transformedNormal = uNormalMatrix * aVertexNormal;                
        float diffuseLightAmount = max( dot(transformedNormal, pointLightDirection), 0.0);	    
	    vLight = ambientLight + (diffuseLightAmount * pointLightColor);
    }
</script>