<script id="shader-fs" type="x-shader/x-fragment">
	uniform sampler2D uFBOTexture;
	uniform sampler2D uSampler;
	uniform highp mat3 uNormalMatrix;
	uniform highp mat4 uMVMatrix;
	uniform highp mat4 uPMatrix;
	uniform	highp vec3 uLightPosition;

	varying highp vec4 vColor;
	varying highp vec3 vPosition;
	varying highp vec2 vTextureCoord;
	varying highp vec3 N;
	varying highp vec4 shadowPosition;
	varying highp float fog_z;
	
	//http://spidergl.org/example.php?id=6
	highp float unpack_depth( const in highp vec4 rgba_depth ) {
		const highp vec4 bit_shift = vec4( 1.0 / ( 256.0 * 256.0 * 256.0 ), 1.0 / ( 256.0 * 256.0 ), 1.0 / 256.0, 1.0 );
		highp float depth = dot( rgba_depth, bit_shift );
		return depth;
	}

	void main(void) {
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


		///////////////////////   shadowmap specific code   ///////////////////////
		highp float bias = 0.00005;//0000000001;
		highp vec3 shadowCoordZDivide = shadowPosition.xyz/shadowPosition.w;

		highp vec4 rgba_depth = texture2D( uFBOTexture, shadowCoordZDivide.xy );
		highp float depth = unpack_depth( rgba_depth );
 
		highp float visibility = 1.0;
	
		if( shadowCoordZDivide.z > (depth - bias) )
		{
			visibility = 0.5;
		}		
		///////////////////////   end shadowmap specific code   ///////////////////////
		
		pointLightDirection = vec3(uLightPosition.xyz - vPosition.xyz);
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
    
	    highp vec4 lightColor = vec4(AmbientColour*AmbientIntensity + 
                        diffuseLambert * DiffuseMaterialColour*DiffuseLightIntensity +
                        SpecularColour * specular*SpecularIntensity, vColor.a);

		highp vec4 textureColor = texture2D(uSampler, vec2(vTextureCoord.st) );
		highp vec4 materialColor = vec4(textureColor.xyz * lightColor.xyz, textureColor.a);

        //calculate fog
		highp float fog_density = 0.025;
		highp vec4 fog_color = vec4(0.7, 0.7, 0.7, 0.5);

		highp float fogFactor = exp( -fog_density * fog_density * fog_z * fog_z);
		fogFactor = clamp(fogFactor, 0.0, 1.0);

		materialColor = vec4(materialColor.rgb * visibility, materialColor.a);
		gl_FragColor = mix(fog_color, materialColor, fogFactor );                 
	}
</script>