const commandsContainer = document.querySelector(".commands-container");
const formContainer = document.querySelector(".form-container");
const form = document.querySelector("form");

// Navigation
const viewCommandsBtn = document.querySelector(".view-commands-btn");
const addCommandsBtn = document.querySelector(".add-commands-btn");
const addCommandBtn = document.querySelector(".add-command-btn");

viewCommandsBtn.addEventListener("click", async function () {
  formContainer.classList.add("hidden");
  commandsContainer.classList.remove("hidden");

  await updateCommands();
});

addCommandsBtn.addEventListener("click", function () {
  commandsContainer.classList.add("hidden");
  formContainer.classList.remove("hidden");
});

async function updateCommands() {
  const response = await fetch(
    "./api/commands"
  );

  const result = await response.json();

  let markup = "";

  result.forEach((command) => {
    const { howTo, line, platform } = command;

    markup += `
    <div class="command">
      <h2 class="how-to">${howTo}</h2>
      <p class="platform">${platform}</p>
      <div class="line-container">
        <p class="line">${line}</p>
      </div>
    </div>
    `;
  });

  commandsContainer.innerHTML = markup;
}

form.addEventListener("submit", async function (e) {
  e.preventDefault();

  const howTo = document.querySelector(".how-to-input").value;
  const line = document.querySelector(".line-input").value;
  const platform = document.querySelector(".platform-input").value;

  const command = {
    howTo: howTo,
    line: line,
    platform: platform,
    };


  const response = await fetch(
    "./api/commands",
    {
      method: "POST",
      headers: {
        "Content-Type": "application/json",
      },
      body: JSON.stringify(command),
    }
  );

    updateCommands();

    formContainer.classList.add("hidden");
    commandsContainer.classList.remove("hidden");

    const commands = document.querySelectorAll(".command");

    commands[commands.length - 1].scrollIntoView({ behavior: 'smooth'});

    howTo = line = platform = '';
});


updateCommands();

commandsContainer.addEventListener("click", function (e) {
    const line = e.target.closest('.line');
    if (!line) return;
    const prevText = line.textContent;
    navigator.clipboard.writeText(prevText);
    line.textContent = "📋 Copied to clipboard!";
    setTimeout(function () {
        line.textContent = prevText;
    }, 1000)
})