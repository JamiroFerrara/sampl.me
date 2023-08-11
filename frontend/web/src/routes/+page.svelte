<script lang="ts">
	import { Api, type User } from '../api/client';
	import Pill from '../components/pill.svelte';
	import Player from '../components/player/player.svelte';
	import Waveform from '../components/player/waveform.svelte';
	import { onMount } from 'svelte';

	let inputDemo = '';
	let users: User[] = [];

	onMount(async () => {
		await getUsers();
	});

	async function getUsers() {
		const api = new Api({ baseUrl: 'http://localhost:5280' });
		let res = await api.user.getAllUser();
		users = res.data;
	}

	async function createUser() {
		const api = new Api({ baseUrl: 'http://localhost:5280' });
		let user: User = {
			id: '',
			username: inputDemo,
			password: '1234'
		};
		await api.user.createUser(user);
		await getUsers();
		inputDemo = '';
	}
</script>

<div class="m-8 space-y-4">
	<div class="flex flex-row space-x-4">
		<Pill>Kicks</Pill>
	</div>

	<button type="button" class="btn" on:click={createUser}>new user</button>

	<input class="input" type="search" name="demo" bind:value={inputDemo} placeholder="Search..." />

	<div class="flex flex-col space-y-4">
		{#each users as user}
			<div>
				User: {user.username}
				Password: {user.password}
			</div>
		{/each}
	</div>

	<Player />
</div>
