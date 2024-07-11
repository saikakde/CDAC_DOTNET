package com.app.service;

import java.util.List;

import com.app.entities.Railway;

public interface RailService {
	void add(Railway railway);
	
	void delete(Long id);
	
	List<Railway> getAll();
	
	List<Railway> sortByCategory();
	
	List<Railway> sortByName();

	void update(Railway railway);
	
	Railway findById(Long id);
	
	List<Railway> findBySource(String source);
	
	void deleteByName(String name);
	
	
}
