?
Linea|	CP|  Etiqueta|Instruccion|Operando| Codigo Objeto
1	002010	COPY	START	2010H		---
2	002010		LDX	ZERO		042027
3	002013	MOVECH	LDCH	STR1, X		50A01F
4	002016		STCH	STR2, X		54A023
5	002019		TIX	FOUR		2C202A
6	00201C		JLT	MOVECH		382013
7	00201F	STR1	BYTE	C'HOLA'		484F4C41
8	002023	STR2	RESB	4		---
9	002027	ZERO	WORD	0		000000
10	00202A	FOUR	WORD	4		000004
11	00202D		END			---