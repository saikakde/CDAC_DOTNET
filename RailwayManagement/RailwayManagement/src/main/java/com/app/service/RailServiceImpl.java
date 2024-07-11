package com.app.service;

import java.util.List;
import java.util.Optional;

import javax.transaction.Transactional;

import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Service;

import com.app.custom_exceptions.InvalidCredentialsException;
import com.app.entities.Railway;
import com.app.repository.RailwayRepo;
@Service
@Transactional
public class RailServiceImpl implements RailService{

	@Autowired
	RailwayRepo railwayRepo;
	@Override
	public void add(Railway railway) {
		railwayRepo.save(railway);
	}

	@Override
	public void delete(Long id) {
		railwayRepo.deleteById(id);
	}

	@Override
	public List<Railway> getAll() {
		List<Railway> list = railwayRepo.findAll();
		return list;
	}

	@Override
	public List<Railway> sortByCategory() {
		List<Railway> list = railwayRepo.findAllByOrderByCategoryAsc();
		return list;
	}

	@Override
	public void update( Railway railway) {
		Optional<Railway> optional = railwayRepo.findById(railway.getId());
		if(optional!=null)
		{
			railwayRepo.save(railway);
		}
		
	}

	@Override
	public Railway findById(Long id) {
		return railwayRepo.findById(id).orElseThrow(()-> new InvalidCredentialsException("railway for id not found"));
	}

	@Override
	public List<Railway> findBySource(String name) {
		return railwayRepo.findRailwaysByName(name);
		 
	}

	@Override
	public void deleteByName(String name) {
		railwayRepo.deleteAllByName(name);
		
	}

	@Override
	public List<Railway> sortByName() {
		// TODO Auto-generated method stub
		List<Railway> list = railwayRepo.findAllByOrderByNameAsc();
		return list;
	}

	
}
