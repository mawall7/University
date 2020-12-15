# University

för course controllern Httppatch - problem lösta:

- i startup : kedja på direkt till services AddController !  .AddnewtonsoftJson();
ska inte vara services. före!

- method not allowed!
lösning. ska inte va [HttpPatch("name")] kan bli problem
bara [HttpPatch]
och under : [Route("{name}")]
glöm inte måsvingarna, som säger att det ska vara för ett objekt

-patch replace för att skriva om t.ex. en property . om du anger


ha alltid med ApiController också!  
annars hittas inte metoden vid create och put

problem att lösa! AutoMapper.AutoMapperMappingException: Missing type map configuration or unsupported mapping.

AutoMapper.AutoMapperMappingException: Missing type map configuration or unsupported mapping.

löst! det var för att getcourse returnerar course av typen Task! 
skriv await framför då får man den till bara en course..

 
