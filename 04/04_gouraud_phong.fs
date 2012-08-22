<script id="shader-fs" type="x-shader/x-fragment">
	varying highp vec3 vColor;
    varying highp float diffuseLambert;
    varying highp float specular;

	void main(void) {
		highp float AmbientIntensity = 0.3;
		highp vec3 DiffuseLightIntensity = vec3(0.9, 0.9, 0.9);
		highp float SpecularIntensity = 0.5;

		highp vec3 AmbientColour = vec3(0.1, 0.1, 0.1);
		highp vec3 DiffuseMaterialColour = vColor;
		highp vec3 SpecularColour = vec3(1.0, 1.0, 1.0);
    
	    gl_FragColor = vec4(AmbientColour*AmbientIntensity + 
                        diffuseLambert * DiffuseMaterialColour*DiffuseLightIntensity +
                        SpecularColour * specular*SpecularIntensity,1.0);
	}
</script>