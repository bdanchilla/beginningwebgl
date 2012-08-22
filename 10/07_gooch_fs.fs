<script id="shader-fs" type="x-shader/x-fragment">
	uniform highp mat3 uNormalMatrix;
	uniform highp mat4 uMVMatrix;
	uniform highp mat4 uPMatrix;

	varying highp vec4 vColor;
	varying highp vec3 vPosition;
	varying highp vec3 N;

	void main(void) {		
        highp vec3 pointLightPosition = vec3(1.0,2.0,1.0);

        highp vec3 pointLightDirection = vec3(pointLightPosition.xyz - vPosition.xyz);

		highp mat4 mvp = uPMatrix * uMVMatrix;

        highp vec3 L = vec3(mvp * vec4(pointLightDirection, 1.0));
		highp vec3 V = -vec3(mvp * vec4(vPosition,1.0));

   		highp vec3 l = normalize(L);
    	highp vec3 n = normalize(uNormalMatrix * N);
    	highp vec3 v = normalize(V);
		
		highp vec3 R = reflect(l, n);

		highp float diffuseLambert = dot(l,n);
		highp float Roughness = 1.0;
		highp vec3 DiffuseLightIntensity = vec3(0.9, 0.9, 0.9);
		highp float SpecularIntensity = 0.5;
		highp float shininess = 128.0;

		highp float specular = pow( max(0.0,dot(R,v)), shininess);
    
	    //below is modified from http://3dshaders.com/shaders/CH15-Gooch.frag.txt
		highp vec3  SurfaceColor = vec3(0.75, 0.75, 0.75);
		highp vec3  WarmColor = vec3(0.6, 0.6, 0.0);
		highp vec3  CoolColor = vec3(0.0, 0.0, 0.6);
		highp float DiffuseWarm = 0.45;
		highp float DiffuseCool = 0.45;

 		highp vec3 kcool    = min(CoolColor + DiffuseCool * SurfaceColor, 1.0);
    	highp vec3 kwarm    = min(WarmColor + DiffuseWarm * SurfaceColor, 1.0); 
    	highp vec3 kfinal   = mix( kcool, kwarm, diffuseLambert );

    	gl_FragColor = vec4 ( min(kfinal + specular, 1.0), 1.0 );
	}
</script>