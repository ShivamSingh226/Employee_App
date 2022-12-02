import logo from './logo.svg';
import './App.css';
import { Fragment ,useState} from 'react';
import axios from 'axios';
import { useEffect } from 'react';

function App() {
  const[firstname,setFirstName]=useState("");
  const[lastname,setLastName]=useState("");
  const[Age,setAge]=useState("");
  const[People,setPeople]=useState([]);
  const[PeopleID,setPeopleId]=useState("");


  const url="http://localhost:5192"
  const handleSubmit=(e)=>{

    const data={
       firstName:firstname,
       lastName:lastname,
       age:Age,
       Type: "Add"
    }
    axios.post(`${url}/api/People`,data).then((json)=>{clear();
      getPeople();
    })
    .catch((error)=>{console.log(error)})

    
    
   
    
    // alert(FirstName + " " + LastName + " " + Age)
  }

  const handleUpdate=()=>{

    const data={
      id:PeopleID,
       firstName:firstname,
       lastName:lastname,
       age:Age,
       Type: "Update"
    }
    axios.put(`${url}/api/People`,data).then((json)=>{clear();
      getPeople();
    })
    .catch((error)=>{console.log(error)})

    
    
   
    
    // alert(FirstName + " " + LastName + " " + Age)
  }
  const handleDelete=(id)=>{
    const data={
       id:id,
       Type: "Delete"
    }
    axios.delete(`${url}/api/People/${id}`,data).then((json)=>{clear();
      getPeople();
    })
    .catch((error)=>{console.log(error)})

  }
  const handleEdit=(id)=>{
    setPeopleId(id);
    const data={
      
       id:id
       
    }
    axios.get(`${url}/api/People/${id}`,data).then((json)=>{
      if(json){
        setFirstName(json.data.responseData.firstName);
        setLastName(json.data.responseData.lastName);
        setAge(json.data.responseData.age);
      }
    })
    .catch((error)=>{console.log(error)})

  }
  const getPeople=()=>{
    axios.get(`${url}/api/People`).then((json)=>{setPeople(json.data.responseData);
    }).catch((error)=>{console.log(error)})
  }
  
  useEffect(() => {
    getPeople();
  }, [])

  const clear=()=>{
    setFirstName("")
    setLastName("")
    setAge("")

  }
  return (
    
         <Fragment>
          <div style={{margin:"0 auto ",margin:"50px"}}>
          <input type="text" value={firstname} placeholder='Enter First Name' onChange={(e)=>setFirstName(e.target.value)}/>
          <br></br>
          <input type="text" value={lastname} placeholder='Enter Last Name' onChange={(e)=>setLastName(e.target.value)}/>
          <br></br>
          <input type="text" value={Age} placeholder='Enter Age' onChange={(e)=>setAge(e.target.value)}/>
          <br></br>
          
          <button onClick={(e)=>handleSubmit(e)}>Save</button>
          &nbsp;&nbsp;
          <button onClick={(e)=>handleUpdate(e)}>Update</button>
          </div>
          <br></br>
          <table style={{width:"500px",backgroundColor:"green",margin:"0 auto"}}>
            <thead>
              <th>IDNo</th>
              <th>FirstName</th>
              <th>LastName</th>
              <th>Age</th>
              <th colSpan={2}>Action</th>

            </thead>
            <tbody>
              {
                People && People.map((peep,ind)=>{
                  return(
                    <tr key={ind}>
                      <td>{peep.id}</td>
                      <td>{peep.firstName}</td>
                      <td>{peep.lastName}</td>
                      <td>{peep.age}</td>
                      <td>
                        <button onClick={()=>handleEdit(peep.id)}>Edit</button>
                      </td>
                      <td>
                      <button onClick={()=>handleDelete(peep.id)}>Delete</button>
                      </td>
                    </tr>
                  )
                })
              }
            </tbody>
          </table>
         </Fragment>
  );
}

export default App;
