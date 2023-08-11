<script lang="ts">
	import { onMount } from 'svelte';
	import { api } from '../api/api';
	import type { User } from '../api/client';
	import Login from '../components/login/login.svelte';

	let users: User[] = [];

	async function getUsers() {
		let res = await api.user.getAllUser();
		users = res.data;
	}

	function onUserCreated() {
		getUsers();
	}

	onMount(async () => {
		await getUsers();
	});
</script>

<Login {onUserCreated} />

{#each users as user}
	<div>
		User: {user.username}
		Password: {user.password}
	</div>
{/each}
