CREATE OR REPLACE FUNCTION Cleanup_RemovedPosts() 
	RETURNS void AS $$
		BEGIN
			DELETE FROM PostRemovals
				WHERE Removed = 1
		END;
	$$ LANGUAGE plpgsql;