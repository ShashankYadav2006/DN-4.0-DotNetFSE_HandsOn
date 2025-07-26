import Trainer from './trainer';

const trainers = [
  new Trainer(1, "Rohit Mehra", "rohit.mehra@example.com", "9876543210", "React", ["Hooks", "Redux", "JSX"]),
  new Trainer(2, "Sneha Kapoor", "sneha.kapoor@example.com", "8765432109", "Angular", ["RxJS", "NgRx", "Forms"]),
  new Trainer(3, "Arjun Verma", "arjun.verma@example.com", "7654321098", "Vue", ["Vuex", "Composition API", "CLI"]),
  new Trainer(4, "Anjali Sharma", "anjali.sharma@example.com", "6543210987", "Node.js", ["Express", "MongoDB", "REST"]),
  new Trainer(5, "Kabir Malhotra", "kabir.malhotra@example.com", "5432109876", "Python", ["Flask", "Pandas", "NumPy"]),
];

export default trainers;
