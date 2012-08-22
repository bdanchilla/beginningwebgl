<script id="shader-fs" type="x-shader/x-fragment">
	uniform highp mat3 uNormalMatrix;
	uniform highp mat4 uMVMatrix;
	uniform highp mat4 uPMatrix;
	
	uniform int uFBO;

	varying highp vec4 vColor;
	varying highp vec3 vPosition;
	varying highp vec3 N;

	void main(void) {
		highp vec4 color = vColor;
	 	
	 	highp vec3 pointLightPosition;
	 	highp vec3 pointLightDirection;
		highp mat4 mvp;
		highp vec3 L;
	    highp vec3 V;
		highp vec3 l;
		highp vec3 n;
	    highp vec3 v;
		highp vec3 R;
		highp float diffuseLambert;
		highp float Roughness;
		highp float AmbientIntensity;
		highp vec3 DiffuseLightIntensity;
		highp float SpecularIntensity;
		highp float shininess;		
		highp float specular;
		highp vec3 AmbientColour;
		highp vec3 DiffuseMaterialColour;
		highp vec3 SpecularColour;

		if(uFBO == 0)
		{	        
			pointLightPosition = vec3(5.0,1.0,5.0);
			pointLightDirection = vec3(pointLightPosition.xyz - vPosition.xyz);
			mvp = uPMatrix * uMVMatrix;

	        L = vec3(mvp * vec4(pointLightDirection, 1.0));
			V = -vec3(mvp * vec4(vPosition,1.0));

	   		l = normalize(L);
	    	n = normalize(uNormalMatrix * N);
	    	v = normalize(V);
			
			R = reflect(l, n);

			diffuseLambert = dot(l,n);
			Roughness = 1.0;
			AmbientIntensity = 0.3;
			DiffuseLightIntensity = vec3(0.9, 0.9, 0.9);
			SpecularIntensity = 0.5;
			shininess = 128.0;

			specular = pow( max(0.0,dot(R,v)), shininess);

			AmbientColour = vec3(0.1, 0.1, 0.1);
			DiffuseMaterialColour = vColor.xyz;
			SpecularColour = vec3(1.0, 1.0, 1.0);
	    
		    color = vec4(AmbientColour*AmbientIntensity + 
	                        diffuseLambert * DiffuseMaterialColour*DiffuseLightIntensity +
	                        SpecularColour * specular*SpecularIntensity, vColor.a);
	    }
	    
	    gl_FragColor = color;                  
}
</script>