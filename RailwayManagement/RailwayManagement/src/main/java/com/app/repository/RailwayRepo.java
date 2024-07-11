package com.app.repository;

import java.util.List;

import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.stereotype.Repository;

import com.app.entities.Railway;

@Repository
public interface RailwayRepo extends JpaRepository<Railway, Long> {
	
	/*
	 * @Query("SELECT r FROM Railway r ORDER BY r.category") List<Railway>
	 * sortByCategory(Category category);
	 */
	
//	List<Railway> findAllOrderByCategoryAsc();
	List<Railway> findAllByOrderByCategoryAsc();
	List<Railway> findRailwaysByName(String source);
	
	void deleteAllByName(String name);
	
	List<Railway> findAllByOrderByNameAsc();
	
}
