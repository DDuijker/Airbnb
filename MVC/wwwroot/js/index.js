function createRandomOrbs(number) {

   let orbs = [];
   for (let x = 0; x < number; x++) {

      const orb = document.createElement("div");
      orb.className = "orb"
      orb.id = `orb${x}`
      orbs.push(orb);
   }

   for (var orb of orbs) {

      randomX = Math.random() * window.innerWidth * 0.9 + 'px';
      randomY = Math.random() * window.innerHeight * 0.7 + 'px';

      orb.style.left = (randomX)
      orb.style.top = (randomY)
      Math.random() * number + 1
      orb.style.zIndex = Math.random() * number + 1
      let randomWidth = Math.random() * 12 + 2
      orb.style.width = `${randomWidth}vw`
      orb.style.aspectRatio = 1
      document.body.appendChild(orb);
   }

}
createRandomOrbs(18);




const handleOnMouseMove = e => {
   const { currentTarget: target } = e

   const rect = document.body.getBoundingClientRect(),
      x = e.clientX - rect.left,
      y = e.clientY - rect.top;
   if (e.movementX < 0) {
      let oldX = parseInt(target.style.left.slice(0, -2))
      target.style.setProperty("left", `${oldX - e.movementX * -0.6}px`);

   } if (e.movementX > 0) {

      let oldX = parseInt(target.style.left.slice(0, -2))
      target.style.setProperty("left", `${oldX + e.movementX * 0.6}px`);
   }
   if (e.movementY < 0) {
      let oldY = parseInt(target.style.top.slice(0, -2))
      target.style.setProperty("top", `${oldY - e.movementY * -0.6}px`);
   } if (e.movementY > 0) {
      let oldY = parseInt(target.style.top.slice(0, -2))
      target.style.setProperty("top", `${oldY + e.movementY * 0.6}px`);
   }
}

function ButtonActions() {
   let overViewButton = document.getElementById("overview")
   overViewButton.addEventListener(("click"), () => {

   })

   const orbs = document.getElementsByClassName("orb")

   for (let orb of orbs) {

      orb.addEventListener('mousemove', (e) => handleOnMouseMove(e))

   }
}

ButtonActions()