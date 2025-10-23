const $ = (sel) => document.querySelector(sel);
const $list = $("#list");
const $status = $("#status");
const $error = $("#error");
const $empty = $("#empty");
const $q = $("#q");
const $url = $("#url");
const $btn = $("#btnLoad");

let rawItems = [];

function setStatus(msg){ $status.textContent = msg || ""; }
function showError(msg){ $error.hidden = !msg; $error.textContent = msg || ""; }
function setEmpty(show){ $empty.hidden = !show; }
function clearList(){ $list.innerHTML = ""; }

function normalizeValue(v){
  if(v == null) return "";
  if(typeof v === "object"){
    try{ return JSON.stringify(v, null, 2); }catch{ return "[objeto]"; }
  }
  return String(v);
}

function render(items){
  clearList();
  setEmpty(!items || items.length === 0);
  if(!items || items.length === 0) return;

  for(const obj of items){
    const itemEl = document.createElement("section");
    itemEl.className = "item";

    const titleText = obj.title ?? obj.name ?? obj.id ?? "Item";
    const headerBtn = document.createElement("button");
    headerBtn.className = "item-header";
    headerBtn.setAttribute("aria-expanded", "false");

    const titleEl = document.createElement("span");
    titleEl.className = "item-title";
    titleEl.textContent = String(titleText);

    const chevron = document.createElement("span");
    chevron.className = "chevron";
    chevron.setAttribute("aria-hidden", "true");
    chevron.textContent = "›";

    headerBtn.appendChild(titleEl);
    headerBtn.appendChild(chevron);


    const details = document.createElement("div");
    details.className = "details";
    const kv = document.createElement("div");
    kv.className = "kv";

    const keys = Object.keys(obj);
    for(const k of keys){
      if (k === "title" || k === "name") continue; 
      const kEl = document.createElement("div");
      const vEl = document.createElement("div");
      kEl.className = "k";
      vEl.className = "v";
      kEl.textContent = k;
      vEl.textContent = normalizeValue(obj[k]);
      kv.appendChild(kEl);
      kv.appendChild(vEl);
    }
    details.appendChild(kv);

    headerBtn.addEventListener("click", () => {
      const expanded = headerBtn.getAttribute("aria-expanded") === "true";
      headerBtn.setAttribute("aria-expanded", String(!expanded));
      details.classList.toggle("open", !expanded);
    });

    itemEl.appendChild(headerBtn);
    itemEl.appendChild(details);
    $list.appendChild(itemEl);
  }
}

function applyFilter(){
  const q = $q.value.trim().toLowerCase();
  if(!q){ render(rawItems); return; }

  const filtered = rawItems.filter(obj =>
    Object.values(obj).some(v => normalizeValue(v).toLowerCase().includes(q))
  );
  render(filtered);
  setStatus(`${filtered.length} de ${rawItems.length} item(ns) (filtrados)`);
}

async function load(){
  const url = "https://jsonplaceholder.typicode.com/posts";
  if(!url){ showError("Informe uma URL de JSON válida."); return; }

  setStatus("Carregando…");
  showError("");

  try{
    const res = await fetch(url, { headers: { "accept": "application/json" } });
    if(!res.ok) throw new Error(`HTTP ${res.status} - ${res.statusText}`);

    const data = await res.json();
    let items = [];
    if (Array.isArray(data)) {
      items = data;
    } else if (data && Array.isArray(data.items)) {
      items = data.items;
    } else if (data && typeof data === "object") {
      items = [data];
    }

    rawItems = items;
    render(rawItems);
    setStatus(rawItems.length ? `Carregado ${rawItems.length} item(ns).` : "Carregado, mas não há itens.");
  }catch(err){
    showError("Falha ao carregar: " + (err?.message || err));
    setStatus("");
  }
}

load();
