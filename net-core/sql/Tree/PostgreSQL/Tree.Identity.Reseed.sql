-- Identity Reseed

SELECT setval(pg_get_serial_sequence('"public"."dummy_tree"', 'id'), 1);
