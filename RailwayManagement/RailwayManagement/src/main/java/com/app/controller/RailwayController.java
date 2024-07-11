package com.app.controller;

import java.util.List;

import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.http.HttpStatus;
import org.springframework.http.ResponseEntity;
import org.springframework.web.bind.annotation.DeleteMapping;
import org.springframework.web.bind.annotation.GetMapping;
import org.springframework.web.bind.annotation.PathVariable;
import org.springframework.web.bind.annotation.PostMapping;
import org.springframework.web.bind.annotation.PutMapping;
import org.springframework.web.bind.annotation.RequestBody;
import org.springframework.web.bind.annotation.RequestMapping;
import org.springframework.web.bind.annotation.RestController;

import com.app.entities.Railway;
import com.app.service.RailServiceImpl;

@RestController
@RequestMapping("/Railway")
public class RailwayController {

	@Autowired
	RailServiceImpl railService;
	
	@PostMapping
	public ResponseEntity<?> addRailway(@RequestBody Railway railway) {
		if(railway!=null) {			
			railService.add(railway);
			return ResponseEntity.status(HttpStatus.OK).body("inserted");
		}
		return ResponseEntity.status(HttpStatus.BAD_REQUEST).body("isnert failed");

	}
	
	@GetMapping
	public ResponseEntity<?> getAll() {
			List<Railway> list = railService.getAll();
			if(list!=null) {
				
			return ResponseEntity.status(HttpStatus.OK).body(list);
		}
		return ResponseEntity.status(HttpStatus.BAD_REQUEST).body("display failed");

	}
	
	@DeleteMapping("{id}")
	public ResponseEntity<?> delete(@PathVariable Long id){
		railService.delete(id);
		return ResponseEntity.status(HttpStatus.OK).body("deleted");
	}
	
	@PutMapping
	public ResponseEntity<?> update(@RequestBody Railway railway)
	{
		if(railway!=null) {
			railService.update(railway);
			return ResponseEntity.status(HttpStatus.OK).body("updated");

		}
		return ResponseEntity.status(HttpStatus.BAD_REQUEST).body("update failed");

	}
	
	@GetMapping("sort/sortByCategory")
	public ResponseEntity<?> sortByCategory()
	{
	 List<Railway> list = railService.sortByCategory();
	 if(list!=null) {
			
			return ResponseEntity.status(HttpStatus.OK).body(list);
		}
		return ResponseEntity.status(HttpStatus.BAD_REQUEST).body("display failed");

	}
	
	@GetMapping("sort/sortByName")
	public ResponseEntity<?> sortByName()
	{
	 List<Railway> list = railService.sortByName();
	 if(list!=null) {
			
			return ResponseEntity.status(HttpStatus.OK).body(list);
		}
		return ResponseEntity.status(HttpStatus.BAD_REQUEST).body("display by name failed");
	}
	
	@GetMapping("search/{name}")
	public ResponseEntity<?> searchBySource(@PathVariable String name){
		 List<Railway> list = railService.findBySource(name);
		 if(list!=null) {
				
				return ResponseEntity.status(HttpStatus.OK).body(list);
			}
			return ResponseEntity.status(HttpStatus.BAD_REQUEST).body("display failed");

	}	
	
	@DeleteMapping("delete/{name}")
	public void deleteByNames(@PathVariable String name) {
		railService.deleteByName(name);
	}
	
}
	

