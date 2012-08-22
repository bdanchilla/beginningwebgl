<script type="x-shader/x-vertex">
	attribute vec3 aVertexPosition;
	attribute vec3 aVertexColor;
	attribute vec3 aVertexNormal;
	attribute vec2 aVertexTexCoord;

	uniform mat3 uNormalMatrix;
	uniform mat4 uMVMatrix;
	uniform mat4 uPMatrix;

	varying highp vec4 vColor;	
	varying highp vec3 vLight;
	varying highp vec2 vTextureCoord;

	void main(void) {
		gl_Position = uPMatrix * uMVMatrix * vec4(aVertexPosition, 1.0);
        vColor = vec4(aVertexColor, 1.0);
    	vTextureCoord = aVertexTexCoord;
    
		//lighting
        vec3 ambientLight = vec3(0.3, 0.3, 0.3);

        vec3 pointLightPosition = vec3(1.0,2.0,-1.0);
        vec3 pointLightDirection = normalize(vec3(pointLightPosition.xyz - aVertexPosition.xyz));

 		vec3 L = vec3(uPMatrix * uMVMatrix * vec4(pointLightDirection, 1.0));
        vec3 N = uNormalMatrix * aVertexNormal; 	               
        float diffuseLightAmount = max( dot(normalize(N), normalize(L)), 0.0); 

	    vLight = (ambientLight + diffuseLightAmount)*2.0;
    }
</script>