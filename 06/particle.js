function Particle(position, color){
  	if (position === undefined) { 
  		position = [	((Math.random()-.5)*.1),
						((Math.random()-.5)*.1),
						((Math.random()-.5)*.1),
					];
	}
	if (color === undefined) { color = [1.0, 0.0, 0.0, 0.5]; }

	this.position = position;
	this.color = color;

	this.velocity = [	((Math.random()-.5)*.1),
						((Math.random()-.5)*.1),
						((Math.random()-.5)*.1),
					];
	if(
		(Math.abs(this.velocity[0]) < 0.01) && 				
		(Math.abs(this.velocity[1]) < 0.01) && 				
		(Math.abs(this.velocity[2]) < 0.01) 
	)					
	{
		//ensure particle is not stagnant
		this.velocity[0] = 0.1;
	}
	this.age = 0;
	this.lifespan = 20;
	this.size = 1.0;
}

Particle.prototype.update = function(){
	this.position[0] += (0.1 * this.velocity[0]);
	this.position[1] += (0.1 * this.velocity[1]);
	this.position[2] += (0.1 * this.velocity[2]);

	var x = Math.abs(this.position[0]);
	var y = Math.abs(this.position[1]);
	var z = Math.abs(this.position[2]);

	var distance = x*x + y*y + z*z;
	if(distance > 4)
	{
		this.position = [	
				(Math.random()*2.0)-1.0,
				(Math.random()*2.0)-1.0,
				(Math.random()*2.0)-1.0
		];
		this.velocity = [	(Math.random()*2.0)-1.0,
						(Math.random()*2.0)-1.0,
						(Math.random()*2.0)-1.0
					];
		if(this.age < 10)
		{				
			this.color = [1.0, 1.0, 1.0, 0.75];			
		}else if(this.age < this.lifespan)
		{	
			this.color = [0.0, 0.0, 1.0, 0.75];
		}else
		{	
			this.color = [1.0, 1.0, 1.0, 0.0];			
		}	
		this.age++;
	}
}