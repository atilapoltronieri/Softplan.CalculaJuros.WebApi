#language: pt-br

Funcionalidade: Verificar Calculo Juros da Api
		
	Cenário: Obter o resultado do juros
		Dado que o valor inicial é 100
		E que o valor do meses é 5
		Quando chamar a api de calculo
		Entao o valor calculado será 105,10