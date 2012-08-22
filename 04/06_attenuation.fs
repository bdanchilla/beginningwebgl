<script id="shader-fs" type="x-shader/x-fragment">
	uniform highp mat3 uNormalMatrix;
	uniform highp mat4 uMVMatrix;
	uniform highp mat4 uPMatrix;

	varying highp vec4 vColor;
	varying highp vec3 vPosition;
	varying highp vec3 N;

	void main(void) {
        highp vec3 pointLightPosition = vec3(5.0,1.0,5.0);

        highp vec3 pointLightDirection = vec3(pointLightPosition.xyz - vPosition.xyz);
		highp float d = length(pointLightDirection);
		highp float attenuation = 1.0/(.01 + .01*d+.02*d*d);

		highp mat4 mvp = uPMatrix * uMVMatrix;

        highp vec3 L = vec3(mvp * vec4(pointLightDirection, 1.0));
		highp vec3 V = -vec3(mvp * vec4(vPosition,1.0));

   		highp vec3 l = normalize(L);
    	highp vec3 n = normalize(uNormalMatrix * N);
    	highp vec3 v = normalize(V);
		
		highp vec3 R = reflect(l, n);

		highp float diffuseLambert = dot(l,n);
		highp float Roughness = 1.0;
		highp float AmbientIntensity = 0.3;
		highp vec3 DiffuseLightIntensity = vec3(0.9, 0.9, 0.9);
		highp float SpecularIntensity = 0.5;
		highp float shininess = 128.0;

		highp float specular = pow( max(0.0,dot(R,v)), shininess);

		highp vec3 AmbientColour = vec3(0.1, 0.1, 0.1)*attenuation;
		highp vec3 DiffuseMaterialColour = vColor.xyz*attenuation;
		highp vec3 SpecularColour = vec3(1.0, 1.0, 1.0)*attenuation;
    
	    gl_FragColor = vec4(AmbientColour*AmbientIntensity + 
                        diffuseLambert * DiffuseMaterialColour*DiffuseLightIntensity +
                        SpecularColour * specular*SpecularIntensity, vColor.a);
	}
</script>