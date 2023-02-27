//To do: Find a way to properly implement Userinputs 
//Goal: Play two different animations at the same time 

   
// Test 1: animation cycle

function playAnimations() {
  // animation 1 set for every 1000ms
  var animation1 = setInterval(() => {
    
    var color = randomRGB();
    console.log("Animation 1: " + color);
  }, 1000);

  // animation 2 set for every 2000ms
  var animation2 = setInterval(() => {
    var color = randomRGB();
    console.log("Animation 2: " + color);
  }, 2000);
}


//Test 2: Not a loop
function playAnimationsTwo() {
    // animation 1
    setTimeout(() => {
      
      var color = randomRGB();
      console.log("Animation 1: " + color);
      
    }, 1000);
  
    // animation 2
    setTimeout(() => {
      
      var color = randomRGB();
      console.log("Animation 2: " + color);
     
    }, 2000);
  }


  //First try working with UserInput 
  //Animation Loop again
  
  function playAnimationsThree(user1, user2) {
    // animation 1
    setTimeout(() => {
     
      var color = userColor(user1);
      var json = buildJSON(color); // --->  Timer

      // Send json to WLED API!??
      console.log("Animation 1: " + json);
      setTimeout(() => {
         
          var color = userColor(user1);
          var json = buildJSON(color);
          // Send json to WLED API!??!
          console.log("Animation 1: " + json);
      }, 1000);
    }, 1000);
  
    // animation 2
    setTimeout(() => {
      
      var color = userColor(user2);
      var json = buildJSON(color);

      // Send json to WLED API!!!!
      console.log("Animation 2: " + json);
      setTimeout(() => {
          
          var color = userColor(user2);
          var json = buildJSON(color);

          // Send json to WLED API!!!!!
          console.log("Animation 2: " + json);
      }, 2000);
    }, 2000);
  }
  
  
