
select 
	r.requisicaoId, o.orderTrabalhoId, r.descricao 'Descricao REQ', o.descricao 'Descricao WO',
	sr.descricao 'Status REQ', sot.descricao 'Status WO',
	a.nome, a.email, a.ramal
from 
	requisicao r inner join
	ordemTrabalho o on r.requisicaoId = o.requisicaoId inner join
	statusOrdemTrabalho sot on o.statusOrdemTrabalhoId = sot.statusOrdemTrabalhoId inner join
	statusRequisicao sr on r.statusId = sr.statusId inner join
	analistaSuporte a on o.analistaSuporteId = a.analistaSuporteId
