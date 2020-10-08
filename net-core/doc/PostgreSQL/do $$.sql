DO $$
DECLARE 
  -- переменные
  a integer;
  b integer;  
BEGIN
  -- блок кода
  -- * транзакция запускается автоматически
  -- * для вывода данных удобно использовать RAISE NOTICE 'Data: %', foo;

	a := 1;
	b := 2;
	
	RAISE NOTICE '%', a + b;	
END$$;
