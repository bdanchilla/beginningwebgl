<script id="shader-fs" type="x-shader/x-fragment">
	varying highp vec3 vColor;
    varying highp float diffuseLambert;
    varying highp float specular;

	void main(void) {
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