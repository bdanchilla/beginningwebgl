<script id="shader-fs" type="x-shader/x-fragment">
	uniform sampler2D uFBOTexture;
	uniform highp mat3 uNormalMatrix;
	uniform highp mat4 uMVMatrix;
	uniform highp mat4 uPMatrix;
	uniform	highp vec3 uLightPosition;

	varying highp vec4 vColor;
	varying highp vec3 vPosition;
	varying highp vec3 N;
	varying highp vec4 shadowPosition;

	//http://spidergl.org/example.php?id=6
	highp float unpack_depth( const in highp vec4 rgba_depth ) {
		const highp vec4 bit_shift = vec4( 1.0 / ( 256.0 * 256.0 * 256.0 ), 1.0 / ( 256.0 * 256.0 ), 1.0 / 256.0, 1.0 );
		highp float depth = dot( rgba_depth, bit_shift );
		return depth;
	}

	//http://www.nutty.ca/?page_id=352&amp;link=shadow_map	
	highp float unpack_depth2 (highp vec4 colour)
	{
		const highp vec4 bitShifts = vec4(
			1.0,
			1.0 / 255.0,
			1.0 / (255.0 * 255.0),
			1.0 / (255.0 * 255.0 * 255.0)
		);
		return dot(colour, bitShifts);
	}

	void main(void) {
		highp vec4 color = vColor;	 	
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
		highp float bias = 0.00000000000001;
		highp vec3 shadowCoordZDivide = shadowPosition.xyz/shadowPosition.w;

		highp vec4 rgba_depth = texture2D( uFBOTexture, shadowCoordZDivide.xy );
		highp float depth = unpack_depth( rgba_depth );
		//highp float depth = unpack_depth2( rgba_depth );
 
		highp float visibility = 1.0;
		if(shadowPosition.w > 0.1)
		{
			if( (shadowCoordZDivide.z) > (depth - bias) )
			{
				visibility = 0.5;
			}
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
    
	    color = vec4(AmbientColour*AmbientIntensity + 
                        diffuseLambert * DiffuseMaterialColour*DiffuseLightIntensity +
                        SpecularColour * specular*SpecularIntensity, vColor.a);
	    gl_FragColor = vec4(color.rgb * visibility, color.a);
	}
</script>