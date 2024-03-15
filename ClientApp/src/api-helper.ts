export async function createGarden(gardenData: object) {
  try {
    const response = await fetch('http://localhost:5000/api/Gardens', {
      method: 'POST',
      headers: {
        'Content-Type': 'application/json'
      },
      body: JSON.stringify(gardenData)
    });
    if (response.ok) {
      const responseData = await response.json();
      return responseData;
    } else {
      throw new Error('Failed to create garden');
    }
  } catch (error) {
    console.error('An error occurred:', error);
    throw error;
  }
}
export async function getGardens() {
  try {
    const response = await fetch('http://localhost:5000/api/Gardens', {
      method: 'GET',
      headers: {
        'Content-Type': 'application/json'
      },
    });
    if (response.ok) {
      const responseData = await response.json();
      return responseData.$values;
    } else {
      throw new Error('Failed to fetch gardens');
    }
  } catch (error) {
    console.error('An error occurred:', error);
    throw error;
  }
}
export async function fetchSeeds() {
  try {
    const response = await fetch('http://localhost:5000/api/Seeds', {
      method: 'GET',
      headers: {
        'Content-Type': 'application/json'
      },
    });
    if (response.ok) {
      const responseData = await response.json();
      return responseData.$values;
    } else {
      throw new Error('Failed to fetch seeds');
    }
  } catch (error) {
    console.error('An error occurred:', error);
    throw error;
  }
}
export async function addSeed(seedId: number, gridId: number, locationCode: string) {
  try {
    const requestBody = JSON.stringify({
      gridId: gridId,
      locationCode: locationCode
    });

    const response = await fetch(`http://localhost:5000/api/Grids/AddSeed?seedId=${seedId}`, {
      method: 'POST',
      headers: {
        'Content-Type': 'application/json'
      },
      body: requestBody
    });
    if (response.status === 204) {
      return {};
    } else if (response.ok) {
      const responseData = await response.json();
      return responseData;
    } else {
      throw new Error('Failed to add seed');
    }
  } catch (error) {
    console.error('An error occurred:', error);
    throw error;
  }
}
export async function createSeed(seedData: object) {
  try {
    const response = await fetch('http://localhost:5000/api/Seeds', {
      method: 'POST',
      headers: {
        'Content-Type': 'application/json'
      },
      body: JSON.stringify(seedData)
    });
    if (response.ok) {
      const responseData = await response.json();
      return responseData;
    } else {
      throw new Error('Failed to create garden');
    }
  } catch (error) {
    console.error('An error occurred:', error);
    throw error;
  }
}
export async function getSeedById(seedId: number) {
  try {
    const response = await fetch(`http://localhost:5000/api/Seeds/${seedId}`, {
      method: 'GET',
      headers: {
        'Content-Type': 'application/json'
      },
    });
    if (response.ok) {
      const responseData = await response.json();
      return responseData;
    } else {
      throw new Error('Failed to fetch seed');
    }
  } catch (error) {
    console.error('An error occurred:', error);
    throw error;
  }
}
export async function getGardenById(gardenId: number) {
  console.log('in api call', gardenId);
  try {
    const response = await fetch(`http://localhost:5000/api/Gardens/${gardenId}`, {
      method: 'GET',
      headers: {
        'Content-Type': 'application/json'
      },
    });
    if (response.ok) {
      const responseData = await response.json();
      return responseData;
    } else {
      throw new Error('Failed to fetch garden');
    }
  } catch (error) {
    console.error('An error occurred:', error);
    throw error;
  }
}