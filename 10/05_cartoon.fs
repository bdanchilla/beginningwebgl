<script id="shader-fs" type="x-shader/x-fragment">
	varying highp vec3 vColor;
    varying highp float diffuseLambert;

	void main(void) {
 		highp vec4 color = vec4( vColor * .1, 1.0);

 		if (diffuseLambert > 0.9)
 		{
 		    color = vec4( vColor * .8, 1.0);
 		}else if (diffuseLambert > 0.6){
 		    color = vec4( vColor * .5, 1.0);
 		}else if (diffuseLambert > 0.3){
 		    color = vec4( vColor * .3, 1.0);
		}
    	
    	gl_FragColor = color;
    	//gl_FragColor = vec4(vColor * floor(diffuseLambert*10.0)*.1, 1.0); 		
	}
</script>